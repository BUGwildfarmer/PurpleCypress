## 字符串的输入

* 包含string类的头文件是<string>
  <string.h>是c的标准库的头文件，包含的是字符串处理函数（strcmp)
* 合法输入
  ```c++
  #include<string>
    string str;
    char c1,c2[20];//若是字符串指针，需要及时进行初始化（即指向一个字符数组）
    cin>>str;//cin可以自动转换类型
    cin>>c1;
    cin>>c2;
    scanf("%c",&c1);
    scanf("%s",c2);
    cin.get(c2,5);
    cin.getline(c2,5)//只接受4个字符
    scanf("%s",&str[0]);//注意：scanf("%s",str)是不合法的
    gets(c2);
    getline(cin,str);
    str.resize(100);//重新分配空间即将其字符数组化，可以使得一些赋值操作合法化
    gets(&str[0]);
    printf("%s",c2);
    cout<<str;
  ```
* !!!scanf和cin操作，都是在缓冲区中遇到空格、tab和回车即停止输入，而且最后的回车会依然留在缓存区中(有时候需要考虑fflush或getchar())
  !!!只有gets，cin.geuline,getline才能接收空格并输出，而且最后的回车会被吃掉，不留在缓存中