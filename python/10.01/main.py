from math import atan2


class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y


def get_manhattan_distance(point, other_point):
    return abs(point.x - other_point.x) + abs(point.y - other_point.y)


def has_line_of_sight(point, other_point, points):
    angle = atan2(point.y - other_point.y, point.x - other_point.x)

    return not any(
        p is not point and
        p is not other_point and
        atan2(point.y - p.y, point.x - p.x) == angle and
        get_manhattan_distance(point, p) < get_manhattan_distance(point, other_point)
        for p in points)


with open('input.txt', encoding='utf-8-sig') as file:
    points = [Point(x, y)
              for y, line in enumerate(file.readlines())
              for x, char in enumerate(list(line.rstrip()))
              if char == '#'
              ]


result = map(lambda point: sum(
    1 for other_point in points
    if point is not other_point
    and has_line_of_sight(point, other_point, points)), points)

print(max(result))
