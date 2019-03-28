public class MinHeapComparer : IComparer {
    public int Compare(object obj1, object obj2) {
        int int1 = (int) obj1;
        int int2 = (int) obj2;
        
        return int1 - int2;
    }
}

public class MaxHeapComparer : IComparer {
    public int Compare(object obj1, object obj2) {
        int int1 = (int) obj1;
        int int2 = (int) obj2;
        
        return int2 - int1;
    }
}

public class Heap<T> {
    
    private List<T> data;
    public int size;
    private IComparer comparer;
    
    public Heap (IComparer comparer) {
        this.data = new List<T>();
        this.size = 0;
        this.comparer = comparer;
    }
    
    public void Insert(T data) {
        
        this.data.Add(data);
        this.size++;
        
        this.BubbleUp(this.size - 1);
    }
    
    public T Peek() {
        if (this.size > 0) {
            return data[0];
        }
        
        return default(T);
    }
    
    public T Get() {
        
        if(this.size == 0) {
            return default(T);   
        }
        
        T minElement = this.data[0];
        
        Swap(this.data, 0, this.size - 1);
        this.data.RemoveAt(this.size - 1);
        
        this.size--;
        
        this.BubbleDown(0);
        return minElement;
    }
    
    private void BubbleUp(int index) {
        
        while(index > 0) {
            
            int parentIndex = this.GetParent(index);
            
            if (this.comparer.Compare(this.data[index],this.data[parentIndex]) < 0 ) {
                Swap(this.data, index, parentIndex);
            }
            
            index = parentIndex;
        }
    }
    
    private void BubbleDown(int index) {
        
        while (index < this.size) {
            
            int leftIndex = this.GetLeftChild(index);
            int rightIndex = this.GetRightChild(index);
        
            int minIndex = index;
            
            if (leftIndex < this.size && this.comparer.Compare(this.data[minIndex], this.data[leftIndex]) > 0 ) {
                minIndex = leftIndex;
            }
            
            if (rightIndex < this.size && this.comparer.Compare(this.data[minIndex], this.data[rightIndex]) > 0 ) {
                minIndex = rightIndex;
            }
            
            if(minIndex == index){
                break;
            }
            else {
                Swap(this.data, index, minIndex);
                index = minIndex;
            }
        }
    }
    
    private int GetParent(int i ) {
        return (i - 1) / 2;
    }
    
    private int GetLeftChild(int i) {
        return i * 2 + 1;
    }
    
    private int GetRightChild (int i) {
        return i * 2 + 2;
    }
    
    private void Swap(List<T> data, int i, int j){
        
        T temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }
}
