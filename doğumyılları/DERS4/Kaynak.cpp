#include <iostream>
using namespace std;
int main()
{
	int dogumyili;
	cout << "do�du�unuz y�l� giriniz: ";
	cin >> dogumyili;

	int suankiyil;
	cout << "suanki yil: ";
	cin >> suankiyil;

	int yas = 0;

	for (int i=dogumyili;i<=suankiyil;i++)
	{
		if (i < suankiyil)
		cout << i << ";";
		else
		cout << i << ".";
		yas++;
	}
	cout << endl << endl;
	cout << "Dogum yilin:" << dogumyili;
	cout << "�uanki yil: " << suankiyil;
	cout << "ben " << yas << "yas�nday�m.";




	return 0;
}