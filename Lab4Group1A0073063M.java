// Tay Yang Shun A0073036M

/*
 * This Exercise is to walk through the solution of the problem on Huffman Tree construction.
 * You want to build a custom Huffman tree for a particular file. Your input will consist of an array of objects
 * such that each object contains a reference to a symbol occurring in that file and the frequency of occurrence (weight) 
 * for the symbol in that file.
 * 
 * Questions will be asked in a form of comment and the answer must be entered below it in the comment to make 
 * the resulting file remains as compilable. Marks allocated to questions are shown and marks given will be stated.
 * Total Marks allocated: 31
 * Total marks obtained: 24
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
/* q1[1 mark] Why is "implements Serializable" needed?
 * It is needed in order to write the file into a data file that can be stored externally.
 *                                                                                            mark obtained: 1
 * */
    // Nested Classes
    /** A datum in the Huffman tree. */
    public static class HuffData implements Serializable {
/* q2[1 mark] Why is Nested Classes needed?
 * Because each HuffData classes in the Huffman Tree is a nodes that stores data
 *  *                                                                                         mark obtained: 0
 *
 * */
      
        // Data Fields

        /** The weight or probability assigned to this HuffData. */
        private double weight;
        /** The alphabet symbol if this is a leaf. */
        private Character symbol;

        public HuffData(double weight, Character symbol) {
            this.weight = weight;
/* q3[1 mark] Why is this needed?
 * To indicate the frequency of occurence of the character
 *  *                                                                                         mark obtained: 0
 *
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
 * A comparison function, which imposes a total ordering on some collection of objects. 
 * Comparators can be passed to a sort method (such as Collections.sort or Arrays.sort) to allow precise control over the sort order. 
 * Comparators can also be used to control the order of certain data structures (such as sorted sets or sorted maps), or to provide an ordering for collections of objects that don't have a natural ordering.
 *  *                                                                                         mark obtained: 1
 *
 * */
/* q5[1 mark] Why is it Comparator<BinaryTree<HuffData>> and not Comparator<CompareHuffmanTrees>?
 * Because we want to compare between HuffData classes which stores the data of the symbols.
 *  *                                                                                         mark obtained: 0
 *
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
 * Means that this self-written function will be used in place of the one given in the Java API.
 *  *                                                                                         mark obtained: 1
 *
 * */
        
        public int compare(BinaryTree<HuffData> treeLeft,
                BinaryTree<HuffData> treeRight) {
/* q7[1 mark] Why is the method return type int?
 * The return type is the relative position of the comparison. A negative integer indicates that the first argument is
 * lesser than the second argument in terms of the ordering defined. 0 indicates equal and a positive integer indicates that the
 * second argument is bigger than the first argument.
 *  *                                                                                         mark obtained: 1
 *
 * */
          
            double wLeft = treeLeft.getData().weight;
            double wRight = treeRight.getData().weight;
            return Double.compare(wLeft, wRight);
/* q8[1 mark] Why is the method Double.compare being used? 
 * Because the weight is of type double and we are comparing the weight.
 *  *                                                                                         mark obtained: 1
 *
 * */
/* q9[1 mark] Is it the same as wLeft - wRight?
 * No it is not. If wLeft is negative and wRight is positive, the return value will be a negative which 
 * indicates that the first argument is smaller than the second argument, which is not correct logically.
 *  *                                                                                         mark obtained: 1
 *
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
 * A PriorityQueue implements the Queue interface.
 *  *                                                                                         mark obtained: 1
 *
 * */
 /* q11[1 mark] What is being managed by this PriorityQueue?
 * The ordering of the elements in the PriorityQueue as defined by natural ordering or the Comparator object.
 *  *                                                                                         mark obtained: 0
 *
 * */
 /* q12[1 mark] Why is Queue being used on the lhs instead of using PriorityQueue?
 * It is good practice to use the interface on the left side as it indicates the capability of an object
 * (which methods it is able to perform).
 *  *                                                                                         mark obtained: 1
 *
 * */
 /* q13[1 mark] What are the 2 parameters (symbols.length, new CompareHuffmanTrees())being used for ?
 * Creates a PriorityQueue with the initial capacity of symbols.length and one that orders 
 * its elements according to the specified comparator.
 *  *                                                                                         mark obtained: 1
 *
 * */
        
        // Load the queue with the leaves.
        for (HuffData nextSymbol : symbols) {
 /* q14[1 mark] What is this for loop used for?
 * It is used to add HuffData objects storing the symbols into the HuffmanTree
 *  *                                                                                         mark obtained: 1
 *
 * */          
            BinaryTree<HuffData> aBinaryTree =
                    new BinaryTree<HuffData>(nextSymbol, null, null);
 /* q15[1 mark] What is the above statement doing?
 * It is creating a BinaryTree object with only the root node that stores the data, nextSymbol.
 *  *                                                                                         mark obtained: 1
 *
 * */              
            theQueue.offer(aBinaryTree);
 /* q16[1 mark] What is the above statement doing and what is offer?
 * It adds the BinaryTree object into the PriorityQueue object theQueue.
 * Offer inserts the specified element into this priority queue.
 *  *                                                                                         mark obtained: 1
 *
 * */            
        }

        // Build the tree.
        while (theQueue.size() > 1) {
            BinaryTree<HuffData> left = theQueue.poll();
            BinaryTree<HuffData> right = theQueue.poll();
  /* q17[1 mark] Why do we call poll twice?
 * Because we want to get both the left and right node of a particular node.
 * Poll is used to retrieve and remove the head of this queue, or returns null if this queue is empty.
 *  *                                                                                         mark obtained: 1
 *
 * */            
           
            double wl = left.getData().weight;
            double wr = right.getData().weight;
            HuffData sum = new HuffData(wl + wr, null);
  /* q18[1 mark] What is the above statement doing?
 * It is creating a new HuffData object with the weight of the left and right node as the data.
 *  *                                                                                         mark obtained: 1
 *
 * */            
            BinaryTree<HuffData> newTree =
                    new BinaryTree<HuffData>(sum, left, right);
  /* q19[1 mark] What is the above statement doing?
 * It is constructing a new BinaryTree with sum as the root, and left and right BinaryTrees 					1
 * as the left and right subtrees respectively.
 * 
 * */            
            theQueue.offer(newTree);
  /* q20[1 mark] What is the above statement doing?
 * It inserts the newTree back into the PriorityQueue object.
 *  *                                                                                         mark obtained: 1
 *
 * */            
              
        }

        // The queue should now contain only one item.
        huffTree = theQueue.poll();
  /* q21[1 mark] Under what condition that huffTree has only one element?
 * When the construction of the huffTree is complete, all HuffData objects are inserted into the Binary Huffman Tree.
 *  *                                                                                         mark obtained: 0
 *
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
 * When the data in the root is null.
 *  *                                                                                         mark obtained: 0
 *
 * */            
          
            if (theData.symbol.equals(' ')) {
  /* q23[1 mark] Why is this case treated differently?
 * Because other characters are printd out directly according to the symbol stored in the node.
 * However, a space character isn't obviously visible to a person, 
 * hence instead of printing a space character, the string "space" is printed instead.
 *  *                                                                                         mark obtained: 1
 *
 * */               
                out.println("space: " + code);
            } else {
                out.println(theData.symbol + ": " + code);
            }
        } else {
            printCode(out, code + "0", tree.getLeftSubtree());
            printCode(out, code + "1", tree.getRightSubtree());
  /* q24[1 mark] What are the above 2 calls used for?
 * It is used to traverse the Huffman Tree and print out other symbols in the tree. "0" and "1"
 * are appended to indicate a left and right traversal respectively.
 *  *                                                                                         mark obtained: 1
 *
 * */               
            
        }
    }

    /**
     * Outputs the resulting code.
     * @param out A PrintStream to write the output to
     */
    public void printCode(PrintStream out) {
  /* q25[1 mark] What is thee difference between the 2 versions of printCode?
 * This printCode is a public method that can be accessed outside the package while
 * the other printCode is a private method used internally.
 *  *                                                                                         mark obtained: 1
 *
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
 * To provide a mutable object that is able to append new String objects at the end it. It is not
 * a good practice to create new String objects, a StringBuilder is preferred.
 *  *                                                                                         mark obtained: 1
 *
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
 * It decodes the code by traversing the tree, according to the sequence specified
 * in the codedMessage string. It turns left in the trees when it sees a '0' in the codedMessage and 
 * turns right if it sees a '1'.
 *  *                                                                                         mark obtained: 0
 *
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
 * Yes it is.
 *  *                                                                                         mark obtained: 1
 *
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
 * No.
 *  *                                                                                         mark obtained: 1
 *
 * */
      for (Map.Entry<Character, String> e : map.entrySet()) {
   /* q30[1 mark] What is entrySet()  ?
 * It returns a Set view of the mappings contained in this map.
 *  *                                                                                         mark obtained: 1
 *
 * */
        
            codesList.add(e.getValue());
        }
        return codesList.toArray(new String[codesList.size()]);
   /* q31[1 mark] Can we return codesList directly?
 * No the return type has to be a String object
 *  *                                                                                         mark obtained: 1
 *
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
