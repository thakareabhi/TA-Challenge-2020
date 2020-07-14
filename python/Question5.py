import sys
# modify this function, and create other functions below as you wish
def question05(num_list, value):
    ist_len = len(num_list)

   

       
    value_table = [0]

   
    for i in range(1, value+1):
        value_table.append(sys.maxsize);

    
    for i in range(1, value+1):
        for j in range(0, list_len):
            if (num_list[j] <= i):
                  tmp = value_table[i-num_list[j]]
                  if ((tmp != sys.maxsize) and (tmp + 1 < value_table[i])):
                      value_table[i] = tmp + 1

     
    return value_table[value]
    
