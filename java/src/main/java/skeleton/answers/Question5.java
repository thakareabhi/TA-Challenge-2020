package skeleton.answers;

public class Question5 {

    public static int shareExchange(int[] arr, int sum) {
       int curr_sum, i, j; 
  
        // Pick a starting point 
        for (i = 0; i < arr.length; i++) { 
            curr_sum = arr[i]; 
  
            // try all subarrays starting with 'i' 
            for (j = i + 1; j <= arr.length; j++) { 
                if (curr_sum == sum) { 
                    int p = j - 1; 
                    System.out.println( 
                        "Sum found between indexes " + i 
                        + " and " + p); 
                    return (i-p); 
                } 
                if (curr_sum > sum || j == arr.length) 
                    break; 
                curr_sum = curr_sum + arr[j]; 
            } 
        } 
  
        System.out.println("No subarray found"); 
        return 0; 
    }
}
