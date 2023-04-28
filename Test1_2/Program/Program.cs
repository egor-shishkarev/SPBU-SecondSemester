using SparseVector;


int[] ints = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 3, 0 };
var vector = new SparceVector(ints);
vector.PrintVector();
vector[0] = 1;
vector.PrintVector();
Console.WriteLine(vector[7]);
vector[0] = 0;
vector.PrintVector();
