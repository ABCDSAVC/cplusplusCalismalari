#include <iostream>
using namespace std;
int main()
{
	int dogumyili;
	cout << "doğduğunuz yılı giriniz: ";
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
	cout << "şuanki yil: " << suankiyil;
	cout << "ben " << yas << "yasındayım.";




	return 0;
}