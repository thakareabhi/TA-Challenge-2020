package skeleton.answers;

public class Question5 {

    public static int shareExchange(int[] numbers, int sum) {
     
                ArrayList minSet = new ArrayList();
                 int flag=0;
                for(int i=numbers.length-1; i&gt;=0; i--) 
                {
                           sum = sum - numbers[i];
                           minSet.add( new Integer(numbers[i]) );
                                  if(sum &lt;=0) 
                                  {
                                     return minSet.size();
                                  }
                }
          
                    
           return 0;
        
    }
}
