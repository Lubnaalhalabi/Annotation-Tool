using System;
namespace Services
{
    public interface IDataDecompresser
    {
        public abstract void Decompress(string topath, string frompath);
    }
}