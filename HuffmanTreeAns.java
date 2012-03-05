/*
 * This Exercise is to walk through the solution of the problem on Huffman Tree construction.
 * You want to build a custom Huffman tree for a particular file. Your input will consist of an array of objects
 * such that each object contains a reference to a symbol occurring in that file and the frequency of occurrence (weight) 
 * for the symbol in that file.
 * 
 * Questions will be asked in a form of comment and the answer must be entered below it in the comment to make 
 * the resulting file remains as compilable. Marks allocated to questions are shown and marks given will be stated.
 * Total Marks allocated: 31
 * Total marks obtained: 
 * */

import java.io.PrintStream;
import java.io.Serializable;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.Queue;
import java.util.Map;
import java.util.SortedMap;
import java.util.TreeMap;
import java.util.List;
import java.util.ArrayList;

/**
 * Class to represent and build a Huffman tree.
 * @author Koffman and Wolfgang
 **/
public class HuffmanTree implements Serializable {
/* q1[1 mark] Why is implements Serializable needed?
 * [ans]This is to enable objects of this class can be written to files and read from files as a whole object.
 * */
    // Nested Classes
    /** A datum in the Huffman tree. */
    public static class HuffData implements Serializable {
/* q2[1 mark] Why is Nested Classes needed?
 * [ans] http://download.oracle.com/javase/tutorial/java/javaOO/nested.html
 *
 * It is used to hide a class in another class that uses it.
 * There are several compelling reasons for using nested classes, among them:
 * 1) It is a way of logically grouping classes that are only used in one place.
 * 2) It increases encapsulation.
 * 3) Nested classes can lead to more readable and maintainable code.
 * */
      
        // Data Fields

        /** The weight or probability assigned to this HuffData. */
        private double weight;
        /** The alphabet symbol if this is a leaf. */
        private Character symbol;

        public HuffData(double weight, Character symbol) {
            this.weight = weight;
/* q3[1 mark] Why is this needed?
 * [ans]This is needed as the parameter weight shadows the attribute weight.
 * 
 * TA: The question asked for the keyword "this" and why is it needed so you need to explain what the keyword does.
 * If you just tell me "It assigns the weight to the object", your answer is not sufficient. 

 * this: Within an instance method or a constructor, this is a reference to the current object — the object whose method or constructor is being called. 
 * You can refer to any member of the current object from within an instance method or a constructor by using this.
 * 
 * http://docs.oracle.com/javase/tutorial/java/javaOO/thiskey.html
 * */
            
            this.symbol = symbol;
        }

        public Character getSymbol() {return symbol;}
    }
    // Data Fields
    /** A reference to the completed Huffman tree. */
    protected BinaryTree<HuffData> huffTree;

    /** A Comparator for Huffman trees; nested class. */
    private static class CompareHuffmanTrees
            implements Comparator<BinaryTree<HuffData>> {
/* q4[1 mark] What is a Comparator?
 * [ans]A Comparator is an interface that specifies the method compare(T o1, T o2) that has to be implemented so that it
 * can be used by the algorithms.
 * */
/* q5[1 mark] Why is it Comparator<BinaryTree<HuffData>> and not Comparator<CompareHuffmanTrees>?
 * [ans]The objects to be compared in compare(T o1, T o2) are of type BinaryTree<HuffData>
 * */

        /**
         * Compare two objects.
         * @param treeLeft The left-hand object
         * @param treeRight The right-hand object
         * @return -1 if left less than right,
         * 0 if left equals right,
         * and +1 if left greater than right
         */
        @Override
/* q6[1 mark] What is the meaning of @Override?
 * [ans]To highlight in the document that a method from a superclass has been overridened. 
 * */
        
        public int compare(BinaryTree<HuffData> treeLeft,
                BinaryTree<HuffData> treeRight) {
/* q7[1 mark] Why is the method return type int?
 * [ans]It is required by the interface Comparator to be of type int.
 * 
 * TA: It is not sufficient to tell me that the method returns an integer because Double.return returns an integer
 * What is important here is that this method is defined by the Comparator interface and this class is implementing the Comparator interface.
 * If the method signature is different you will not be able to compile your code at all
 * */
          
            double wLeft = treeLeft.getData().weight;
            double wRight = treeRight.getData().weight;
            return Double.compare(wLeft, wRight);
/* q8[1 mark] Why is the method Double.compare being used? 
 * [ans] So as to return the sign of the difference between wLeft and wRight correctly.
 * */
/* q9[1 mark] Is it the same as wLeft - wRight?
 * [ans]It is difference as Double.compare(wLeft, wRight) returns -1, 0, or 1 to indicate the sign
 * */            
        }
    }

    /**
     * Builds the Huffman tree using the given alphabet and weights.
     * @post  huffTree contains a reference to the Huffman tree.
     * @param symbols An array of HuffData objects
     */
    public void buildTree(HuffData[] symbols) {
        Queue<BinaryTree<HuffData>> theQueue =
                new PriorityQueue<BinaryTree<HuffData>>(symbols.length, new CompareHuffmanTrees());
 /* q10[1 mark] What is the relationship between PriorityQueue and Queue?
 * [ans]PriorityQueue implement Queue interface
 * 
 * TA: The question is asking for "relationship". If you explain what is a PriorityQueue and what is a Queue without
 * telling me how they are related, you are not answering the question. Please also note that Queue is a interface so PriorityQueue is 
 * not a subclass of Queue. 
 * */
 /* q11[1 mark] What is being managed by this PriorityQueue?
 * [ans]BinaryTree<HuffData>
 * TA: The question simply asked for what is the type of items that the PriorityQueue holds. Answers that explain what is a PriorityQueue 
 * and how it works are not accepted 
 * */
 /* q12[1 mark] Why is Queue being used on the lhs instead of using PriorityQueue?
 * [ans]To make the code more flexible, it is a good practice to use the interface as the type of the object
 * instantiated from a class that implement the interface.
 * */
 /* q13[1 mark] What are the 2 parameters (symbols.length, new CompareHuffmanTrees())being used for ?
 * [ans]size of the PriorityQueue to be created and an object that is a comparator (so that compare() can be used)
 * */
        
        // Load the queue with the leaves.
        for (HuffData nextSymbol : symbols) {
 /* q14[1 mark] What is this for loop used for?
 * [ans]It is used to iterate through the symbol array
 * */          
            BinaryTree<HuffData> aBinaryTree =
                    new BinaryTree<HuffData>(nextSymbol, null, null);
 /* q15[1 mark] What is the above statement doing?
 * [ans]Create a single node of a binary tree with the value in the node nextSymbol and empty left and right subtree.
 * 
 * */              
            theQueue.offer(aBinaryTree);
 /* q16[1 mark] What is the above statement doing and what is offer?
 * [ans]Insert the binary tree into the queue
 * */            
        }

        // Build the tree.
        while (theQueue.size() > 1) {
            BinaryTree<HuffData> left = theQueue.poll();
            BinaryTree<HuffData> right = theQueue.poll();
  /* q17[1 mark] Why do we call poll twice?
 * [ans] To retrieve the two binary trees with the lowest frequencies
 * */            
           
            double wl = left.getData().weight;
            double wr = right.getData().weight;
            HuffData sum = new HuffData(wl + wr, null);
  /* q18[1 mark] What is the above statement doing?
 * [ans]Construct a HuffData object with its weight field being wl + wr with no symbol associated with it (null)
 * */            
            BinaryTree<HuffData> newTree =
                    new BinaryTree<HuffData>(sum, left, right);
  /* q19[1 mark] What is the above statement doing?
 * [ans] The creation of a binarytree object
 * */            
            theQueue.offer(newTree);
  /* q20[1 mark] What is the above statement doing?
 * [ans] Insert this newly created binarytree object into the queue
 * */            
              
        }

        // The queue should now contain only one item.
        huffTree = theQueue.poll();
  /* q21[1 mark] Under what condition that huffTree has only one element?
 * [ans]When there is only one symbol
 * */        
    }

    /**
     * Outputs the resulting code.
     * @param out A PrintStream to write the output to
     * @param code The code up to this node
     * @param tree The current node in the tree
     */
    private void printCode(PrintStream out, String code,
            BinaryTree<HuffData> tree) {
        HuffData theData = tree.getData();
        if (theData.symbol != null) {
  /* q22[1 mark] When will symbol be null?
 * [ans]When the binary tree node is not a leaf node 
 * */            
          
            if (theData.symbol.equals(' ')) {
  /* q23[1 mark] Why is this case treated differently?
 * [ans]To make the code stand out instead of printing " : "
 * */               
                out.println("space: " + code);
            } else {
                out.println(theData.symbol + ": " + code);
            }
        } else {
            printCode(out, code + "0", tree.getLeftSubtree());
            printCode(out, code + "1", tree.getRightSubtree());
  /* q24[1 mark] What are the above 2 calls used for?
 * [ans]To recursively process the left subtree and the right subtree
 * */               
            
        }
    }

    /**
     * Outputs the resulting code.
     * @param out A PrintStream to write the output to
     */
    public void printCode(PrintStream out) {
  /* q25[1 mark] What is thee difference between the 2 versions of printCode?
 * [ans]This version is the starter and the other version is used for recursion
 * 
 * TA: I do not accept answers that tell me the parameters are different. You need to 
 * be able to identify that one of the method is public and the other is private. The reason is 
 * that the private method is a recursive method and it takes in parameters that are private 
 * within the class (tree) and a empty code. These are not necessary parameters for the public 
 * method as it adds complexity and breaks the encapsulation concept. Hence we create a public 
 * method to call the private method. 
 * */       
        printCode(out, "", huffTree);
    }

    /**
     * Method to decode a message that is input as a string of
     * digit characters '0' and '1'.
     * @param codedMessage The input message as a String of
     *        zeros and ones.
     * @return The decoded message as a String
     */
    public String decode(String codedMessage) {
        StringBuilder result = new StringBuilder();
   /* q26[1 mark] Why is StringBuilder needed?
 * [ans]StringBuilder is used for building up a long string efficiently
 * */       
        BinaryTree<HuffData> currentTree = huffTree;
        for (int i = 0; i < codedMessage.length(); i++) {
            if (codedMessage.charAt(i) == '1') {
                currentTree = currentTree.getRightSubtree();
            } else {
                currentTree = currentTree.getLeftSubtree();
            }
            if (currentTree.isLeaf()) {
                HuffData theData = currentTree.getData();
                result.append(theData.symbol);
                currentTree = huffTree;
   /* q27[1 mark] Why the above statement is needed?
 * [ans]To prepare for decoding the code of the next symbol 
 * TA: The question asked for the "above statement" not the "above statements" hence you need to explain why
 * we have "currentTree = huffTree;". 

 * Everytime we finish decoding a character (which is when we reached a leaf node),
 * we need to reset the currentTree so that it starts from the main root and we can decode the next character.
 * */                
            }
        }
        return result.toString();
    }
    /**
     * A method encode for the HuffmanTree class that encodes a String of 
     * letters that is passed as its first argument. Assume that a second 
     * argument, codes (type String[]), contains the code strings (binary 
     * digits) for the symbols (space at position 0, a at position 1, b 
     * at position 2, and so on).
     * @param str String to be encoded
     * @param codes Array of codes
     * @param return Encoded string
     * @throws ArrayIndexOutOfBoundsException if str contains a character
     * other than a letter or space.
     */
    public static String encode(String str, String[] codes) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < str.length(); i++) {
            char c = str.charAt(i);
            int index = 0;
            if (c != ' ') {
                index = Character.toUpperCase(c) - 'A' + 1;
            }
   /* q28[1 mark] Is index computed correctly?
 * [ans] Yes. If the character is a space, then the index should be 0, else it should be the difference in the
 * alphabet positions of this character with 'A' and add 1 to it.
 * TA: Answers that point out that lower case character are not taken into consideration are accepted 
 * */              
            result.append(codes[index]);
        }
        return result.toString();
    }

    /**
     * Method to build the code array.  Result is an ordered array of Strings
     * where the first item is the code for the smallest symbol in the
     * array of symbols.
     * @return Array of codes
     */
    public String[] getCodes() {
        SortedMap<Character, String> map = new TreeMap<Character, String>();
        String currentCode = "";
        buildCode(map, currentCode, huffTree);
        List<String> codesList = new ArrayList<String>();
   /* q29[1 mark] Must a List be used?
 * [ans] No. We can use a String array.
 * */
      for (Map.Entry<Character, String> e : map.entrySet()) {
   /* q30[1 mark] What is entrySet()  ?
 * [ans]It provides a way to regard map as a set so that we can use set iterator to iterate through all the entries
 * */
        
            codesList.add(e.getValue());
        }
        return codesList.toArray(new String[codesList.size()]);
   /* q31[1 mark] Can we return codesList directly?
 * [ans]No, codesList is a List whereas the method return type is String[]
 * */         
    }

    private void buildCode(Map<Character, String> map, String code, BinaryTree<HuffData> tree) {
        HuffData theData = tree.getData();
        if (theData.symbol != null) {
            map.put(theData.symbol, code);
        } else {
            buildCode(map, code + "0", tree.getLeftSubtree());
            buildCode(map, code + "1", tree.getRightSubtree());
        }
    }
}
