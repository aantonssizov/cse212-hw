public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];

        for (int selectItm = 0, list1Counter = 0, list2Counter = 0; selectItm < select.Length; selectItm++)
        {
            if (select[selectItm] == 1)
            {
                result[selectItm] = list1[list1Counter++];
            }
            else
            {
                result[selectItm] = list2[list2Counter++];
            }
        }

        return result;
    }
}