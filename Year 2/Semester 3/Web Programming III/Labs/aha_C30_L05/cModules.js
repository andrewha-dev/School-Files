var PI = Math.PI;
var geometry = {
	areaCircle: function(r, done){
		process.nextTick(function(){
			done(null,PI*r*r);
		});
	},
	areaRect: function(length, width, done){
		process.nextTick(function(){
			done(null, length * width);
		});
	},
	perimRect: function(length, width, done){
		process.nextTick(function(){
			done(null,2*( length + width));
		});
	},
	isTriangle: function(side1, side2, side3, done){
		process.nextTick(function(){
			done(null, ((side1 + side2 > side3)) && (side1+side3 > side2) && (side3+side2> side1))

		})
	}
	
}
module.exports = geometry;

