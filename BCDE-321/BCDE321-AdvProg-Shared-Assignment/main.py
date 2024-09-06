import cmd
from cmd_commands import Commands
# Use the assigned Files Main.py will still be used but just as the "Launcher"

# THE CLI INTERFACE WILL LOOK SOMETHING LIKE:
# [Starting Sequence] Do you wish to Start the game or get help? (Start/Help)
# >>> Start
# You are in the Foyer - [Doors: N]
# Which way do you wish to move? M:
# >>> N
# Moving North.
# /Drawing New Map Tile/
# Kitchen Tile has been drawn - [Doors: N, E, S]
# Do you wish to Rotate (90º)? Y/Nn
# >>> Y
# Kitchen Tile - [Doors: E,S,W]
# Do you wish to Rotate (90º)? Y/N
# >>> N
# /Placing Tile/
# You are in the Kitchen - [Doors: E,S,W]
# Which way do you wish to move? M:

if __name__ == '__main__':
    print(Commands.intro)
    Commands().cmdLoop()
