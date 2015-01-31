require_relative 'grid.rb'
require_relative 'rover.rb'

grid = Grid.new
rover = Rover.new

puts "Landing rover at (#{rover.currentPos.x}, #{rover.currentPos.y})... landed"
rover.assignGrid grid

#get user input
puts "Move forward(f), move backward(b), turn left(l), turn right(r) OR exit"
input = gets

while !input.eql?("exit\n") do
  #go through each character in input
  input.each_char { |ch|
    case ch
      when 'f'
        break if !(rover.moveForward)
      when 'b'
        break if !(rover.moveBackward)
      when 'l'
        rover.turnLeft
      when 'r'
        rover.turnRight
    end
  }

  rover.displayPosition
  puts "Move forward(f), move backward(b), turn left(l), turn right(r) OR exit"
  input = gets
end