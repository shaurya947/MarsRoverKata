class Rover
  def initialize (startingX = 0, startingY = 0, startingDir = :north)
    @currentPos = Point.new(startingX, startingY)
    @currentDir = startingDir
  end

  attr_reader :currentPos, :currentDir

  #method to assign grid to rover
  def assignGrid grid
    @grid = grid

    #if starting point of rover is at an obstacle, move rover over till hit free spot
    if @grid.obstacles.include?(@currentPos)
      print "Grid has obstacle at rover starting position. Landed rover at ("

      loop do
        moveForward
        break if !@grid.obstacles.include?(@currentPos)
      end

      print "#{@currentPos.x}, #{@currentPos.y}) instead\n"
    end
  end

  #method to move rover one step forward
  #display error and return false if obstacle lies ahead
  def moveForward
    case @currentDir
      when :north
        incrementY
      when :south
        decrementY
      when :east
        incrementX
      when :west
        decrementX
    end

    #if new current position has obstacle, move back and report it
    if @grid.obstacles.include?(@currentPos)
      puts "Cannot move forward. Obstacle present ahead at (#{@currentPos.x}, #{@currentPos.y})"
      moveBackward
      return false
    end

    true
  end

  #method to move rover one step backward
  #display error and return false if obstacle lies behind
  def moveBackward
    case @currentDir
      when :north
        decrementY
      when :south
        incrementY
      when :east
        decrementX
      when :west
        incrementX
    end

    #if new current position has obstacle, move back and report it
    if @grid.obstacles.include?(@currentPos)
      puts "Cannot move backward. Obstacle present behind at (#{@currentPos.x}, #{@currentPos.y})"
      moveForward
      return false
    end

    true
  end

  #method to turn rover to the left
  def turnLeft
    case @currentDir
      when :north
        @currentDir = :west
      when :south
        @currentDir = :east
      when :east
        @currentDir = :north
      when :west
        @currentDir = :south
    end
  end

  #method to turn rover to the right
  def turnRight
    case @currentDir
      when :north
        @currentDir = :east
      when :south
        @currentDir = :west
      when :east
        @currentDir = :south
      when :west
        @currentDir = :north
    end
  end

  #method to increment rover's x position (with wrap around)
  def incrementX
    @currentPos.x += 1
    if @currentPos.x > @grid.maxX
      @currentPos.x = @grid.minX
    end
  end

  #method to decrement rover's x position (with wrap around)
  def decrementX
    @currentPos.x -= 1
    if @currentPos.x < @grid.minX
      @currentPos.x = @grid.maxX
    end
  end

  #method to increment rover's y position (with wrap around)
  def incrementY
    @currentPos.y += 1
    if @currentPos.y > @grid.maxY
      @currentPos.y = @grid.minY
    end
  end

  #method to decrement rover's y position (with wrap around)
  def decrementY
    @currentPos.y -= 1
    if @currentPos.y < @grid.minY
      @currentPos.y = @grid.maxY
    end
  end

  #method to display new position
  def displayPosition
    print "New rover position is (#{@currentPos.x}, #{@currentPos.y}) facing "

    case @currentDir
      when :north
        print "North\n"
      when :south
        print "South\n"
      when :east
        print "East\n"
      when :west
        print "West\n"
    end
  end
end