米勒罗宾素数判别法
```
#include <iostream>
#include <time.h>
using namespace std;
long long an[] = {2,3,5,7,11,13,17,61};
long long Random(long long n)//生成0到n之间的整数
{
    return (double) rand()/RAND_MAX*n+0.5;//(doubel)rand()/RAND_MAX生成0-1之间的浮点数
}
long long q_mod(long long a,long long n,long long p)
{
    a = a%p;
    //首先降a的规模
    long long sum = 1;//记录结果
    while(n)
    {
        if(n&1)
        {
            sum = (sum*a)%p;//n为奇数时单独拿出来乘
        }
        a = (a*a)%p;//合并a降n的规模
        n /= 2;
    }
    return sum;
}
long long q_mul(long long a,long long b,long long p)
{
    long long sum = 0;
    while(b)
    {
        if(b&1)//如果b的二进制末尾是零
        {
            (sum += a)%=p;//a要加上取余
        }
        (a <<= 1)%=p;//不断把a乘2相当于提高位数
        b >>= 1;//把b右移
    }
    return sum;
}
bool witness(long long a,long long n)
{
    long long d = n-1;
    long long r = 0;
    while(d%2==0)
    {
        d/=2;
        r++;
    }//n-1分解成d*2^r，d为奇数
    long long x = q_mod(a,d,n);
    //cout << "d " << d << " r " << r << " x " << x << endl;
    if(x==1||x==n-1)//最终的余数是1或n-1则可能是素数
    {
        return true;
    }
    while(r--)
    {
        x = q_mul(x,x,n);
        if(x==n-1)//考虑开始在不断地往下余的过程
        {
            return true;//中间如果有一个余数是n-1说明中断了此过程，则可能是素数
        }
    }
    return false;//否则如果中间没有中断但最后是余数又不是n-1和1说明一定不是素数
}
bool miller_rabin(long long n)
{
    const int times = 50;//试验次数
    if(n==2)
    {
        return true;
    }
    if(n<2||n%2==0)
    {
        return false;
    }
    for(int i = 0;i<times;i++)
    {
        long long a = Random(n-2)+1;//1到(n-1)
        //cout << a << endl;
        if(!witness(a,n))
        {
            return false;
        }
    }
    return true;
}
int main()
{
    long long num;
    cin >> num;
    if(miller_rabin(num))
    {
        cout << "Yes" << endl;
    }
    else
    {
        cout << "No" << endl;
    }
}
```