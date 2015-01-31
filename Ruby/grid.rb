require 'set'
require_relative 'point.rb'

class Grid
  def initialize (maxX = 10, minX = -10, maxY = 10, minY = -10)
    @maxX, @minX, @maxY, @minY = maxX, minX, maxY, minY

    @obstacles = Set.new
    numObstacles = ((maxX - minX) * (maxY - minY)) / 10

    (1..numObstacles).each do |n|
      p = Point.new(rand(minX..maxX), rand(minY..maxY))
      if !@obstacles.include?(p)
        @obstacles.add(p)
      end
    end
  end

  attr_reader :maxX, :minX, :maxY, :minY, :obstacles

  #method to show obstacles
  def showObstacles
    @obstacles.each do |p|
      puts "(#{p.x}, #{p.y})"
    end
  end
end