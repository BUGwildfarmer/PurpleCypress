高次同余方程：x^a=n(mod p)输出所有x
1.先求出p的原根g
2.求出以g为底的b关于模p的指数r,即g^r=b(mod p)(用bsgs求解）
3.令x=g^y(mod p),代回则是g^(ay)=g^r(mod p)
4.exgcd求解ay=r(mod p)
5.在0到phi[p]-1中求得y的解，代回x=g^y(mod p)解得
下面为输出所有解代码
```
#pragma warning(disable:4996)
#include<iostream>
#include<cstdio>
#include<cmath>
#include<cstring>
#include<algorithm>
#include<unordered_map>
using namespace std;
#define int long long
const int N = 201010;
unordered_map<int, int> hsh;
int prime[N], tot, T, phi, ans[N], num, a, b, p, g, x, y;
int read() {
	int sum = 0, f = 1; char ch = getchar();
	while (ch<'0' || ch>'9') { if (ch = '-')f = -1; ch = getchar(); }
	while (ch >= '0'&&ch <= '9') { sum = sum * 10 + ch - '0'; ch = getchar(); }
	return sum * f;
}
void work(int x) {
	int tmp = x;
	tot = 0;
	for (int i = 2; i*i <= x; i++) {
		if (tmp%i == 0) {
			prime[++tot] = i;
			while (tmp%i == 0)tmp /= i;
		}
	}
	if (tmp > 1)prime[++tot] = tmp;
}
int ksm(int x, int b) {
	int tmp = 1;
	while (b) {
		if (b & 1)tmp = tmp * x%p;
		b >>= 1;
		x = x * x%p;
	}
	return tmp;
}
int BSGS(int a, int b) {
	hsh.clear();
	int block = sqrt(p) + 1;
	int tmp = b;
	for (int i = 0; i < block; i++, tmp = tmp * a%p)hsh[tmp] = i;
	a = ksm(a, block);
	tmp = 1;
	for (int i = 0; i <= block; i++, tmp = tmp * a%p) {
		if (hsh.count(tmp) && i*block - hsh[tmp] >= 0)return i * block - hsh[tmp];
	}
}
int exgcd(int &x, int &y, int a, int b) {
	if (b == 0) {
		x = 1; y = 0;
		return a;
	}
	int gcd = exgcd(x, y, b, a%b);
	int z = x;
	x = y; y = z - (a / b)*y;
	return gcd;
}
signed main() {
	T = read();
	while (T--) {
		p = read(), a = read(), b = read();//p为模数，a为指数，b为余数
		b %= p;
		phi = p - 1;
		work(phi);
		for (int i = 1; i <= p; i++) {
			bool flag = false;
			for (int j = 1; j <= tot; j++)if (ksm(i, phi / prime[j]) == 1) { flag = true; break; }
			if (flag == false) { g = i; break; }
		}
		int r = BSGS(g, b);
		int gcd = exgcd(x, y, a, phi);
		if (r%gcd != 0) { printf("No Solution\n"); continue; }
		x = x * r / gcd;
		int k = phi / gcd;
		x = (x%k + k) % k;
		num = 0;
		while (x < phi) { ans[++num] = ksm(g, x), x += k; }
		sort(ans + 1, ans + 1 + num);
		for (int i = 1; i <= num; i++)printf("%lld ", ans[i]);
		printf("\n");
	}
	return 0;
}
```
---
当以上的a=2时，可以用二次剩余定理来写
```
#include<iostream>
#include<cstring>
#include<cstdio>
#include<cmath>
#include<algorithm>
#include<cstdlib>
#include<ctime>
using namespace std;
#define random(a,b) (rand()%(b-a+1)+a)
#define int long long
int n, p, w;
bool flag;
struct complex {
	int x, y;
	complex(int xx = 0, int yy = 0) {
		x = xx; y = yy;
	}
};
complex operator *(complex a, complex b) {
	return complex(((a.x*b.x%p + w * a.y%p*b.y%p) % p + p) % p, ((a.x*b.y%p + a.y*b.x%p) % p + p) % p);
}
int read() {
	int sum = 0, f = 1; char ch = getchar();
	while (ch<'0' || ch>'9') { if (ch = '-')f = -1; ch = getchar(); }
	while (ch >= '0'&&ch <= '9') { sum = sum * 10 + ch - '0'; ch = getchar(); }
	return sum * f;
}
complex ksm(complex x, int b) {
	complex tmp(1, 0);
	while (b) {
		if (b & 1)tmp = tmp * x;
		b >>= 1;
		x = x * x;
	}
	return tmp;
}
int ksm(int x, int b) {
	int tmp = 1;
	while (b) {
		if (b & 1)tmp = tmp * x%p;
		b >>= 1;
		x = x * x%p;
	}
	return tmp;
}
int work(int n) {
	if (p == 2)return n;
	if (ksm(n, (p - 1) / 2) + 1 == p)flag = true;
	int a;
	while (233) {
		a = random(0, p - 1);
		w = ((a*a - n) % p + p) % p;
		if (ksm(w, (p - 1) / 2) + 1 == p)break;
	}
	complex res(a, 1);
	complex ans(0, 0);
	ans = ksm(res, (p + 1) / 2);
	return ans.x;
}
signed main() {
	srand((unsigned)time(NULL));
	p = read(); n = read();
	n %= p;
	int ans1 = work(n);
	int ans2 = p - ans1;
	if (flag) { printf("No Solution\n"); return 0; }
	if (ans1 == ans2)printf("%lld\n", ans1);
	else printf("%lld %lld", min(ans1, ans2), max(ans1, ans2));
	return 0;
}
```