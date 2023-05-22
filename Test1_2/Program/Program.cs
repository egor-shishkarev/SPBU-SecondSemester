using SparseVector;

var vector1 = new SparceVector(new int[] { 5, 0, 0, 0, 1, 4, 0 });
var vector2 = new SparceVector(new int[] { 5, 0, 0, 0, 1, 4, 0 });
var sumVector = SparceVector.Addition(vector1, vector2);
sumVector.PrintVector();