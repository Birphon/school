using System;
using System.IO;
using System.Text;

namespace FileHandler
{
    class LearningFileHandlerStuffUsingSystemIO
    {
        static void Main(string[] args)
        {
            DirectoryInfo defDir = new DirectoryInfo(".");
            DirectoryInfo curDir = new DirectoryInfo(".");
            // Makes a Directory - Will need at a later date for make multiple saves for different "runs"?
            DirectoryInfo memeDir = new DirectoryInfo(@"..\Meme");
            memeDir.Create();
            Console.WriteLine(memeDir.FullName);

            // Deleting Directory
            // memeDir.Delete();

            // Read and Write
            DirectoryInfo rawDir = new DirectoryInfo(@"..\ReadAndWrite");
            rawDir.Create();
            string[] data = { "Level 1", "Level 2", "Level 3" };
            string textFilePath = @"..\ReadAndWrite\Data.txt";
            File.WriteAllLines(textFilePath, data);
            Console.WriteLine(textFilePath);
            try
            {
                using (StreamReader sr = new StreamReader(textFilePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
    }
}


/* Possible List of Tests:
    Misc
    1    Create New Game?
    22   Create Directory for Saves
    23   Delete Save
    24   Delete Directory's
    

    Load
    2    From Default Directory
    3    From Changed Directory
    4    Blank Game
    5    In Progress Game
    6    Half Game (Loading a Level Designer 'save')
    7    Without Error
    8    With Error
    9    With Data Validate
                Must have:
                    Level
                    Map Size
                    Pieces
                    Move Count
                    Player position
                    Player start
                    Goal
                    Previous Moves
                    Last Move
                    # of Undos
                    # of Resets
    



    Save
    10    To Default Directory
    11    To Changed Directory
    12    Overrite Existing file
    13        No Comfirmation
    14        Comfirmation
    15    Without Error
    16    With Error
    17    With Level Name (Default)
    18    With different Name
        With current moves
    19        Move Count
    20        List of Previous moves
    21    With current position
*/