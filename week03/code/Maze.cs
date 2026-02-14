/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE

    // Helper to centralize the checks and movement
    private void TryMove(int directionIndex, int dx, int dy)
    {
        // Pull allowed moves for current cell and validate shape
        if (!_mazeMap.TryGetValue((_currX, _currY), out var allowed) || allowed is not { Length: 4 })
            throw new InvalidOperationException("Can't go that way!");

        // Check if the direction from this cell is allowed
        if (!allowed[directionIndex])
            throw new InvalidOperationException("Can't go that way!");

        // Compute the next coordinate and ensure it exists in the map
        var next = (_currX + dx, _currY + dy);
        if (!_mazeMap.ContainsKey(next))
            throw new InvalidOperationException("Can't go that way!");

        // Apply the move
        _currX = next.Item1;
        _currY = next.Item2;
    }


    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE

        // index 0 = left
        TryMove(directionIndex: 0, dx: -1, dy: 0);

    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE

        // index 1 = right
        TryMove(directionIndex: 1, dx: 1, dy: 0);

    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE

        // index 2 = up
        TryMove(directionIndex: 2, dx: 0, dy: -1);

    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE

        // index 3 = down
        TryMove(directionIndex: 3, dx: 0, dy: 1);

    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}