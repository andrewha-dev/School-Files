const PI = Math.PI;

exports.area = (r) => PI * r * r;

exports.areaRect = (length, width) => length * width;

exports.perimRect = (length, width) => 2 * (length + width);

exports.isTriangle = (side1, side2, side3) =>((side1 + side2 > side3)) && (side1+side3 > side2) && (side3+side2> side1)



