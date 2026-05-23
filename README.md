# Bejeweled Game

A C# console-based implementation of the classic Bejeweled puzzle game.

## Overview

Bejeweled is a tile-matching puzzle game where players swap adjacent gems to create matches of three or more identical colored gems in a row (horizontally or vertically). Matched gems are removed from the board, gems fall to fill empty spaces, and new gems appear to complete the board.

## Features

- 5x5 game board
- Four gem colors: Red (R), Green (G), Blue (B), Yellow (Y)
- Swap adjacent gems to create matches
- Automatic match detection (3+ gems in a row)
- Gravity system - gems fall to fill empty spaces
- Auto-refill with new random gems
- Score tracking (+10 points per matched gem)
- Chain matching support (multiple matches in succession award points)
- Quit game option
- Clean console-based UI with board coordinates

## Requirements

- .NET 10.0 or higher
- C# 12.0 or higher

## Installation

1. Clone the repository:

```bash
git clone <repository-url>
cd BejeweledCode
```

2. Build the project:

```bash
dotnet build
```

## How to Play

1. Run the game:

```bash
dotnet run
```

2. View the board with numbered rows and columns

3. Swap adjacent gems by entering their coordinates:
   - Enter the row and column of the first gem (e.g., `0 0`)
   - Enter the row and column of the second gem (e.g., `0 1`)

4. If three or more gems match after the swap, they're removed and you earn points

5. Type `quit` or `exit` to end the game

## Game Mechanics

### Matching

- Matches require 3 or more consecutive gems of the same color
- Matches can be horizontal or vertical
- Chain matches occur when new gems create additional matches after falling

### Gravity

- When gems are removed, remaining gems fall down to fill empty spaces
- Gravity is applied from bottom to top in each column

### Refilling

- Empty spaces are filled with new random gems
- Initial startup checks for matches and clears them automatically

### Scoring

- Each matched gem earns 10 points
- Points accumulate throughout the game

## Project Structure

### Classes

- **Gem.cs** - Represents a single gem with color and position
- **Board.cs** - Manages the game board grid, gem placement, gravity, and refilling
- **GameController.cs** - Main game logic and loop, handles user input and match checking
- **DisplayManager.cs** - Handles all console output and UI display
- **MoveValidator.cs** - Validates player moves and checks adjacency
- **MatchFinder.cs** - Detects matches of 3+ gems horizontally and vertically

## Commands

During gameplay:

- Enter gem coordinates to swap (format: `row col`)
- Type `quit` or `exit` to end the game

## Example Gameplay

```
=== BEJEWELED ===

  0 1 2 3 4
0 R G B Y R
1 G R Y G B
2 B Y R B G
3 Y R G Y R
4 R B Y R G

Score: 0
Enter first gem position (row col) or 'quit': 0 0
Enter second gem position (row col): 0 1
Swap successful!
Match found! +30 points!
```

## Future Enhancements

- Difficulty levels
- Time-based gameplay
- Power-ups
- Larger boards
- GUI interface
- Sound effects
- High score tracking
