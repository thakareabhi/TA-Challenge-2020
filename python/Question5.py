# modify this function, and create other functions below as you wish
def question05(num_list, value):
    ist_len = len(num_list)

    # We will use the tipycal dynamic programming table construct
    # the key of the list will be the sum value we want, 
    # and the value will be the
    # minimum number of items to sum

    # Base case value = 0, first element of the list is zero   
    value_table = [0]

    # Initialize all table values to MAX
    # for range i use value+1 because python range doesn't include the end
    # number
    for i in range(1, value+1):
        value_table.append(sys.maxsize);

    # try every combination that is smaller than <value>
    for i in range(1, value+1):
        for j in range(0, list_len):
            if (num_list[j] <= i):
                  tmp = value_table[i-num_list[j]]
                  if ((tmp != sys.maxsize) and (tmp + 1 < value_table[i])):
                      value_table[i] = tmp + 1

     
    answer = value_table[value]
    return answer
