package skeleton.answers;

public class Question5 {

    public static int shareExchange(int[] allowedAllocations, int totalValue) {
        // TODO Auto-generated method stub
        
        Arrays.sort(allowedAllocations);
        
        int flag=0;
        
        for (int index = 0; index < allowedAllocations.length; index++) 
        {
            if(allowedAllocations[index] == totalValue)
            {
                   flag=1;
                   break;
            }
            if(allowedAllocations[index]<totalValue)
            {
                break;
            }
        }
        
        
        if(flag==0)
        {
                for (int index = 0; index < allowedAllocations.length; index++) 
                {
                    if(arr[index] == (totalValue/2))
                    {
                           flag=2;
                           break;
                    }
                    if(arr[index]<totalValue)
                    {
                        break;
                    }
                }
        }
        
        int pcnt=0;
        if(flag==0)
        {
                for(int i=0;i<allowedAllocations.length;i++)
                {
                    
                }
        }
        
        if(flag!=0)
        {
            return flag;
        }
         else
        {
             return 0;
        }
    }
}
