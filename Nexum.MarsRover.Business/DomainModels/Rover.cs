using Nexum.MarsRover.Core.ValueObjects;
using Nexum.MarsRover.Core.Enums;
using Nexum.MarsRover.Core.Interfaces;

namespace Nexum.MarsRover.Business.DomainModels
{
    /// <summary>
    /// </summary>
    public class Rover : IRover
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        private readonly Plateau _plateau;

        public Rover(Position position, Direction direction, Plateau plateau)
        {
            Position = position;
            Direction = direction;
            _plateau = plateau;
        }
        public void TurnLeft() =>
            Direction = Direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => Direction
            };

        public void TurnRight() =>
            Direction = Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => Direction
            };

        public void Move()
        {
            int newX = Position.X;
            int newY = Position.Y;

            switch (Direction)
            {
                case Direction.N: newY++; break;
                case Direction.E: newX++; break;
                case Direction.S: newY--; break;
                case Direction.W: newX--; break;
            }

            Position = _plateau.Clamp(new Position(newX, newY));
        }

        /// <summary>Verilen tek karakterlik komutu çalıştırır</summary>
        public void Execute(char command)
        {
            switch (char.ToUpper(command))
            {
                case 'L': TurnLeft(); break;
                case 'R': TurnRight(); break;
                case 'M': Move(); break;
                default:
                    throw new InvalidOperationException($"Geçersiz komut: {command}");
            }
        }

        /// <summary>Rover'ın anlık pozisyonunu ve yönünü döndürür (örn: "1 2 N")</summary>
        public override string ToString() => $"{Position.X} {Position.Y} {Direction}";
    }
}
