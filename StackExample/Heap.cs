using System.Collections;


namespace StackExample;


    public class Heap 
    {
        private object?[] _array; // Yığın elemanları için depolama.
        private int _size; // Yığındaki eleman sayısı.

        private const int _defaultCapacity = 10;

        public Heap()
        {
            _array = new object[_defaultCapacity];
            _size = 0;
        }

        // Belirli başlangıç kapasitesine sahip bir yığın oluşturalım. Başlangıç kapasitesi negatif olmayacak.
        public Heap(int initialCapacity)
        {
            if (initialCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "capacity was less than the current size."); // başlangıç kapasitesi sıfırdan küçük olamaz.

            if (initialCapacity < _defaultCapacity)
                initialCapacity = _defaultCapacity; 
            _array = new object[initialCapacity];     // Yeni depolama alanı oluşturur 
            _size = 0;
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        // Yığındaki tüm elemanları kaldırır.
        public void Clear()
        {
            Array.Clear(_array, 0, _size); // Bunu belgelememize gerek yok, ancak Garbage Collection referansları geri alabilmesi için öğeleri temizliyoruz.
            _size = 0;                               // (Garbage Collection erişilemeyen nesneleri silerek belleğin verimli bir şekilde kullanılmasını sağlamaktadır.)
        }

        public object Clone()   // Bu metot kendisini çağıran dizinin tüm elemanlarını kopyalayıp aynı sırada diğer diziye atar. 
        {
            Heap s = new Heap(_size);
            s._size = _size;
            Array.Copy(_array, s._array, _size);
            return s;
        }

        // Yığında en üstteki nesneyi kaldırmadan döndürür eğer yığın boşsa Peek bir InvalidOperationException oluşturur.
        public object? Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Enumeration already finished");

            return _array[_size - 1];
        }

        //Yığının en üstünden bir öğe çıkarır. Yığın boşsa, Pop bir InvalidOperationException oluşturur.
        public object? Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Enumeration already finished.");
            
            object? obj = _array[--_size];
            _array[_size] = null;     // Free memory quicker.
            return obj;
        }

        // Bir öğeyi yığının en üstüne iter.
        public void Push(object? obj)
        {
            if (_size == _array.Length)
            {
                object[] newArray = new object[2 * _array.Length];
                Array.Copy(_array, newArray, _size);
                _array = newArray;
            }
            _array[_size++] = obj;
        }
    }