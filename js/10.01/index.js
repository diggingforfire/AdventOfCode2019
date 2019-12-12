const fs = require('fs');

const points = fs.readFileSync('input.txt', 'utf8')
	.split('\r\n')
	.map((line, y) => line
		.split('')
		.map((char, x) => ({char, x, y}))
		.filter(point => point.char === '#'))
		.reduce((a, b) => a.concat(b));

const result = Math.max(...points.map(point => points.filter(otherPoint => point != otherPoint && hasLineOfSight(point, otherPoint, points)).length));

console.log(result);

function getManhattanDistance(point, otherPoint) {
	return Math.abs(point.x - otherPoint.x) + Math.abs(point.y - otherPoint.y);
}

function hasLineOfSight(point, otherPoint, points) {
	const angle = Math.atan2(point.y - otherPoint.y, point.x - otherPoint.x);

	// line of sight means there are no other points with the same angle that have a smaller Manhattan distance
	return !points.some(p => 
		p != point && 
		p != otherPoint &&
		Math.atan2(point.y - p.y, point.x - p.x) === angle &&
		getManhattanDistance(point, p) < getManhattanDistance(point, otherPoint));
}
