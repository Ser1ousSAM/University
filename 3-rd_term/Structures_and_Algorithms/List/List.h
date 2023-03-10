//difference between class and typename - first for all, second for internal types(int, char...)
using std::cout;
template<typename T>
class Node;

template<typename T>
class List {
public:
    List();

    ~List() = default;

    int getSize();

    bool isEmpty();

    void pushBack(T);

    void pushFront(T);

    void insert(T, int);

    int indexOf(T);

    T &valueAt(int);

    void print();

    bool remove(T);

    bool removeAt(int);

    bool removeFront();

    bool removeLast();

    void clear();

    void sort();

    int binarySearch(T);

    T &operator[](const int index);

private:
    Node<T> *first;
    Node<T> *last;
    int _size;
};

template<typename T>
class Node {
    T _val;
    Node *_next;
    Node *_prev;

    Node(T _val = T()) : _val(_val), _next(nullptr), _prev(nullptr) {};

    friend class List<T>;
};

template<typename T>
List<T>::List() {
    _size = 0;
    first = nullptr;
    last = nullptr;
}

template<typename T>
int List<T>::getSize() {
    return _size;
}

template<typename T>
bool List<T>::isEmpty() {
    return _size == 0;
}

template<typename T>
void List<T>::pushBack(T _val) {
    Node<T> *temp = new Node<T>(_val);
    if (_size == 0) {
        first = temp;
        last = first;
    } else {
        temp->_prev = last;
        last->_next = temp;
    }
    last = temp;
    _size++;
}

template<typename T>
void List<T>::pushFront(T _val) {
    Node<T> *temp = new Node<T>(_val);
    if (_size == 0) {
        last = temp;
    } else {
        temp->_next = first;
        first->_prev = temp;
    }
    first = temp;
    _size++;
}

template<typename T>
void List<T>::insert(T _val, int index) {
    Node<T> *curr;
    int count;
    if (_size < index)
        throw std::out_of_range("oooooh, ia tebya smorkal");
    if (index == 0) {
        pushFront(_val);
        return;
    }
    if (index == _size) {
        pushBack(_val);
        return;
    }
    if (_size / 2 < index + 1) {
        curr = last;
        count = _size - 1;
        while (count != index) {
            count--;
            curr = curr->_prev;
        }
    } else {
        curr = first;
        count = 0;
        while (count != index) {
            count++;
            curr = curr->_next;
        }
    }
    Node<T> *newIndexEl = new Node<T>(_val);
    newIndexEl->_next = curr;
    newIndexEl->_prev = curr->_prev;
    curr->_prev->_next = newIndexEl;
    curr->_prev = newIndexEl;
    _size++;
}

template<typename T>
int List<T>::indexOf(T _val) {
    Node<T> *curr = first;
    int index = 0;
    while (curr != nullptr) {
        if (curr->_val == _val)
            return index;
        curr = curr->_next;
        index++;
    }
    return -1;
}

template<typename T>
T &List<T>::valueAt(const int index) {
    if (_size <= index || index < 0)
        throw std::out_of_range("oooooh, ia tebya smorkal");
    Node<T> *curr;
    int curr_i;
    if (_size / 2 >= index) {
        curr_i = 0;
        curr = first;
        while (curr != nullptr) {
            if (curr_i == index)
                return curr->_val;
            curr = curr->_next;
            curr_i++;
        }
    } else {
        curr_i = _size - 1;
        curr = last;
        while (curr != nullptr) {
            if (curr_i == index)
                return curr->_val;
            curr = curr->_prev;
            curr_i--;
        }
    }
}

template<typename T>
void List<T>::print() {
    if (!isEmpty()) {
        Node<T> *current = first;
        while (current != nullptr) {
            cout << current->_val << " ";
            current = current->_next;
        }
        cout << '\n';
    }
}

template<typename T>
bool List<T>::remove(T _val) {
    Node<T> *curr = first;
    while (curr != nullptr && curr->_val != _val)
        curr = curr->_next;
    if (curr != nullptr) {
        if (curr->_val == _val) {
            if (curr->_next == nullptr)
                removeLast();
            else if (curr->_prev == nullptr)
                removeFront();
            else {
                curr->_prev->_next = curr->_next;
                curr->_next->_prev = curr->_prev;
                delete curr;
                return true;
            }
        }
    }
    return false;

}

template<typename T>
bool List<T>::removeAt(int index) {
    Node<T> *curr;
    int curr_i;
    if (index < 0 || index >= _size)
        return false;
    else {
        if (index >= _size / 2) {
            curr_i = _size - 1;
            curr = last;
            while (index != curr_i) {
                curr = curr->_prev;
                curr_i--;
            }
        } else {
            curr_i = 0;
            curr = first;
            while (index != curr_i) {
                curr = curr->_next;
                curr_i++;
            }
        }
        if (curr_i == _size - 1)
            removeLast();
        else if (curr_i == 0)
            removeFront();
        else {
            curr->_prev->_next = curr->_next;
            curr->_next->_prev = curr->_prev;
            delete curr;
        }
    }
    return true;
}

template<typename T>
bool List<T>::removeFront() {
    if (_size == 0)
        return false;
    else {
        Node<T> *curr = first->_next;
        curr->_prev = nullptr;
        delete first;
        first = curr;
    }
    return true;
}

template<typename T>
bool List<T>::removeLast() {
    if (_size == 0)
        return false;
    else {
        Node<T> *curr = last->_prev;
        curr->_next = nullptr;
        delete last;
        last = curr;
    }
    return true;
}

template<typename T>
void List<T>::clear() {
    Node<T> *curr = first->_next;
    while (curr != nullptr) {
        delete curr->_prev;
        curr = curr->_next;
    }
    delete curr;
    first = nullptr;
    last = nullptr;
    _size = 0;
}

template<typename T>
void List<T>::sort() {
    Node<T> *curr_i = first;
    while (curr_i->_next != nullptr) {
        T min = curr_i->_val;
        Node<T> *tempMinP;
        Node<T> *curr_j = curr_i->_next;
        bool isChanging = false;
        while (curr_j != nullptr) {
            if (min > curr_j->_val) {
                min = curr_j->_val;
                tempMinP = curr_j;
                isChanging = true;
            }
            curr_j = curr_j->_next;
        }
        if (isChanging) {
            T temp = curr_i->_val;
            curr_i->_val = min;
            tempMinP->_val = temp;
        }
        curr_i = curr_i->_next;
    }
}

template<typename T>
T &List<T>::operator[](const int index) {
    return valueAt(index);
}