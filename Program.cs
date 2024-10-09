// See https://aka.ms/new-console-template for more information

int k = 10;
List<int> A = [2, 1, 3];
List<int> B = [7, 8, 9];

string result = Result.twoArrays(k, A, B);

System.Console.WriteLine(result);

class Result
{

    /*
     * Complete the 'twoArrays' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY A
     *  3. INTEGER_ARRAY B
     */

    public static string twoArrays(int k, List<int> A, List<int> B)
    {
        A.Sort();
        B.Sort();
        int length = A.Count() - 1;
        for (int i = 0; i < length; i++)
        {
            if(A[i] + B[length - i] < k){
                return "NO";
            }
        }
        return "YES";
    }

}