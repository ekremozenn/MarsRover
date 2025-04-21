using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Nexum.MarsRover.Business.InputModels;
using Nexum.MarsRover.Business.Messages;
using Nexum.MarsRover.Business.Executors;
using Nexum.MarsRover.Business.DomainModels;
using Nexum.MarsRover.Core.Enums;
using Nexum.MarsRover.Core.Interfaces;
using Nexum.MarsRover.Core.ValueObjects;
using FluentValidation.Results;

namespace Nexum.MarsRover.Business.Services
{
    /// <summary>
    /// Mars görevini yöneten ana servis. Plateau ve Rover girişlerini alır, doğrular, komutları uygular.
    /// </summary>
    public class MissionControlService
    {
        #region Dependencies

        private readonly IValidator<RoverInputModel> _validator;
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public MissionControlService(IValidator<RoverInputModel> validator, ILogger logger, IServiceProvider serviceProvider)
        {
            _validator = validator;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region Run 

        public void Run()
        {
            Plateau plateau = GetPlateauFromUser();

            for (int i = 1; i <= 2; i++)
            {
                var (position, direction, commandInput) = GetRoverInputFromUser(i, plateau);

                Rover rover = new Rover(position, direction, plateau);

                var executor = ActivatorUtilities.CreateInstance<RoverCommandExecutor>(_serviceProvider, rover);

                _logger.Log(string.Format(UserMessages.RoverCommandStart, i));

                executor.ExecuteCommands(commandInput);

                string finalMessage = string.Format(UserMessages.RoverFinalStatus, i, executor.GetStatus());
                Console.WriteLine(finalMessage);
                _logger.Log(finalMessage);
            }

            Console.WriteLine(UserMessages.MissionComplete);
            _logger.Log(UserMessages.MissionComplete);
        }

        #endregion

        #region Plateau Input

        private Plateau GetPlateauFromUser()
        {
            while (true)
            {
                Console.WriteLine(UserMessages.AskPlateau);
                string plateauInput = Console.ReadLine();

                RoverInputModel dummy = new RoverInputModel
                {
                    PlateauInput = plateauInput,
                    StartPositionInput = "0 0 N",
                    CommandInput = "M"
                };

                ValidationResult result = _validator.Validate(dummy);
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors.Where(e => e.PropertyName == "PlateauInput"))
                    {
                        string message = string.Format(UserMessages.ValidationError, error.ErrorMessage);
                        Console.WriteLine(message);
                        _logger.Log(message);
                    }
                    continue;
                }

                string[] coords = plateauInput.Split(' ');
                return new Plateau(int.Parse(coords[0]), int.Parse(coords[1]));
            }
        }

        #endregion

        #region Rover Input

        private (Position, Direction, string) GetRoverInputFromUser(int roverIndex, Plateau plateau)
        {
            string startInput = string.Empty;
            string commandInput = string.Empty;
            Position position;
            Direction direction;

            // START POSITION INPUT
            while (true)
            {
                Console.WriteLine(string.Format(UserMessages.AskStartPosition, roverIndex));
                startInput = Console.ReadLine()?.Trim().ToUpper();

                var startInputModel = new RoverInputModel
                {
                    PlateauInput = $"{plateau.MaxX} {plateau.MaxY}",
                    StartPositionInput = startInput,
                    CommandInput = "M" // Dummy
                };

                var result = _validator.Validate(startInputModel);
                var errors = result.Errors.Where(e => e.PropertyName == nameof(RoverInputModel.StartPositionInput)).ToList();

                if (errors.Any())
                {
                    string header = string.Format(UserMessages.ValidationHeader, roverIndex);
                    Console.WriteLine(header);
                    _logger.Log(header);

                    foreach (var error in errors)
                    {
                        string msg = string.Format(UserMessages.ValidationError, error.ErrorMessage);
                        Console.WriteLine(msg);
                        _logger.Log(msg);
                    }

                    continue;
                }

                string[] parts = startInput.Split(' ');
                position = new Position(int.Parse(parts[0]), int.Parse(parts[1]));

                if (!Enum.TryParse(parts[2], out direction) || !Enum.IsDefined(typeof(Direction), direction))
                {
                    string error = string.Format(UserMessages.InvalidDirection, parts[2]);
                    Console.WriteLine(error);
                    _logger.Log(error);
                    continue;
                }

                break;
            }

            // COMMAND INPUT
            while (true)
            {
                Console.WriteLine(string.Format(UserMessages.AskCommandInput, roverIndex));
                commandInput = Console.ReadLine()?.Trim().ToUpper();

                var commandInputModel = new RoverInputModel
                {
                    PlateauInput = $"{plateau.MaxX} {plateau.MaxY}",
                    StartPositionInput = "0 0 N", // Dummy
                    CommandInput = commandInput
                };

                var result = _validator.Validate(commandInputModel);
                var errors = result.Errors.Where(e => e.PropertyName == nameof(RoverInputModel.CommandInput)).ToList();

                if (errors.Any())
                {
                    string header = string.Format(UserMessages.ValidationHeader, roverIndex);
                    Console.WriteLine(header);
                    _logger.Log(header);

                    foreach (var error in errors)
                    {
                        string msg = string.Format(UserMessages.ValidationError, error.ErrorMessage);
                        Console.WriteLine(msg);
                        _logger.Log(msg);
                    }

                    continue;
                }

                break;
            }

            return (position, direction, commandInput);
        }

        #endregion
    }
}
