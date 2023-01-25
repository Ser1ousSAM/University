#include <iostream>
#include "list.h"
//difference between class and typename - first for all, second for internal types(int, char...)
using std::cout;

int main() {
    List<int> l;
    l.pushFront(1);
    l.pushFront(2);
    l.pushFront(5);
    l.pushFront(2);
    l.insert(9, 3);
    l.insert(9, 3);
    l.insert(9, 3);
    l.insert(9, 0);
    l[3] = 4;
    cout << l[3] << '\n';
    l.print();
    l.sort();
    l.print();
    l.clear();
    l.print();
    return 0;
}