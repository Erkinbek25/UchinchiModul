namespace modul_3_dars_1;

public class MyList : IMyList
{
    private int[] _nums;
    private int arrIndex = 0;
    public int Capacity
    {
        get { return _nums.Length; }
    }

    public MyList(int capacity = 4)
    {
        _nums = new int[capacity];
    }
    public bool Add(int num)
    {
        if (arrIndex >= Capacity)
        {
            DoubleCapacity();
        }

        _nums[arrIndex] = num;
        arrIndex++;

        return true;
    }

    private void DoubleCapacity()
    {
        int[] newArr = new int[Capacity * 2];
        for (var i = 0; i < Capacity; i++)
        {
            newArr[i] = _nums[i];
        }
        _nums = newArr;
    }

    public bool Contains(int num)
    {
        throw new NotImplementedException();
    }

    public int GetById(int index)
    {
        return _nums[index];
    }

    public int IndexOf(int num)
    {
        for (var i = 0; i < Capacity; i++)
        {
            if (_nums[i] == num)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Remove(int num)
    {
        for (var i = 0; i < Capacity; i++)
        {
            if (_nums[i] == num)
            {
                for (var j = i; j < Capacity - 1; j++)
                {
                    _nums[j] = _nums[j + 1];
                }
                --arrIndex;
                return true;
            }
        }

        return false;
    }

    public bool RemoveAll(int num)
    {
        foreach (var i in _nums)
        {
            if (i == num)
            {
                Remove(num);
            }
        }
        return true;
    }

    public bool RemoveAt(int index)
    {

        for (var j = index; j < Capacity - 1; j++)
        {
            _nums[j] = _nums[j + 1];
        }
        --arrIndex;

        return true;
    }





    public void DisplayElements()
    {
        foreach (var i in _nums)
        {
            Console.Write(i + " ");
        }
    }
}





