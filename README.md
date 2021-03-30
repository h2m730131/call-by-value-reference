# call-by-value-reference

`Programs.cs` 輸出的結果：
```
Call by Value:
  a : 2
  b : 1
  &a: 0x000000005a77e80c
  &b: 0x000000005a77e808

Call by Reference:
  a                   : 3
  ref_int             : 3
  &a                  : 0x000000005a77e80c
  &ref_int / p_ref_int: 0x000000005a77e80c

Call by Address:
  a      : 4
  *p_int : 4
  &a     : 0x000000005a77e80c
  p_int  : 0x000000005a77e80c
  &p_int : 0x000000005a77e7f8
  &*p_int: 0x000000005a77e80c

Narrow:
  a      : 255
  ref_int: 255
  *p_int : 255
  *p_byte: 255
```