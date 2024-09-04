#include <iostream>
using namespace std;
int main()
{
	int number;
	int toplam = 0;
	cout << "lutfen bir sayi giriniz: ";
	cin >> number;

	for (int i = 1; i <= (number/ 2); i++) 
	{
		if (number%i == 0)
		{
			toplam+= i;
			cout << i << endl;
		}
	}
	if (toplam == number)
	{
		cout << "girdiğiniz sayi mükemmel";
	}
	else {
		cout << "girdiğiniz sayi mükemmel değil";
	}
		
		
}
