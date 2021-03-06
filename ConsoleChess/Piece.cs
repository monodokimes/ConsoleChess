using System;
using System.Collections.Generic;

namespace ConsoleChess {
    public abstract class Piece {
        public abstract string Character { get; }
        public abstract int Value { get; }
        public Colour Colour { get; set; }
        public Position Position { get; set; }

        public static List<Piece> GetPawnRow() {
            var pawns = new List<Piece>();
            for (int i = 0; i < 8; i++) {
                pawns.Add(new Pawn());
            }
            return pawns;
        }

        public static List<Piece> GetOfficerRow() {
            return new List<Piece> {
                new Rook(),
                new Knight(),
                new Bishop(),
                new Queen(),
                new King(),
                new Bishop(),
                new Knight(),
                new Rook()
            };
        }

        public Piece() { }

        public abstract List<Vector> GetMovePatterns();

        public void Move(string target) {
            Position = Position.FromAlgebraic(target);
        }
    }

    public class Pawn : Piece {
        public bool HasMoved { get; set; }

        public override string Character => "p";
        public override int Value => 1;

        public override List<Vector> GetMovePatterns() {
            var availableMoves = new List<Vector>();

            var direction = Colour == Colour.White ? -1 : 1;

            availableMoves.Add(new Vector { X = 0, Y = direction });
            if (!HasMoved) {
                availableMoves.Add(new Vector { X = 0, Y = direction * 2 });
            }

            return availableMoves;
        }
    }

    public class Bishop : Piece {
        public override string Character => "B";
        public override int Value => 3;

        public override List<Vector> GetMovePatterns() {
            var availableTargets = Position.GetDiagonals();
            var moves = new List<Vector>();

            foreach (var target in availableTargets) {
                moves.Add(Position.GetMove(target));
            }

            return moves;
        }
    }

    public class Knight : Piece {
        public override string Character => "N";
        public override int Value => 3;

        public override List<Vector> GetMovePatterns() {
            throw new NotImplementedException();
        }
    }

    public class Rook : Piece {
        public override string Character => "R";
        public override int Value => 5;

        public override List<Vector> GetMovePatterns() {
            throw new NotImplementedException();
        }
    }

    public class Queen : Piece {
        public override string Character => "Q";
        public override int Value => 9;

        public override List<Vector> GetMovePatterns() {
            throw new NotImplementedException();
        }
    }

    public class King : Piece {
        public override string Character => "K";
        public override int Value => 0;

        public override List<Vector> GetMovePatterns() {
            throw new NotImplementedException();
        }
    }
}
