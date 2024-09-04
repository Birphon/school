﻿namespace chess_maze
{
    public interface IConverter
    {
        string Expanded { get; }
        string Compressed { get; }
        void Compress(string uncompressedLevel);
        void Expand(string uncompressedLevel);
    }
}
