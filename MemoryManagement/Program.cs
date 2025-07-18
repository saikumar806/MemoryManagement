using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    /*
     * What is memory management
     * Memory management is a process of alloacating the memory and deallocating the memory..
     * In .net memory management is handling by garbage collector.
     * Grabage collector is an integral compoennt of CLR.
     * CLR is an integral component of .net framework.
     * 
     * Manged Heap:
     * Heap is a data structure which can contain collection of objects.
     * Grabage collector is using the Heap data structure for memory management.
     * due to that reason we call it as Managed Heap.
     * 
     * To perform memory management garbage collector will do 2 duties.
     * 1)Allocating the memory.
     * 2)Deallocating the memory or releasing the memory.
     * 
     * Allocating the Memory:
     * When a new object is created by the application garbage collector 
     * will allocate memory for newly created object with in the heap data structure
     * where exactly next pointer is pointing.
     * Next object pointer will be pointing to the next adjacent empty location with in the heap.
     * Heap will be occupied by couple of objects.
     * 
     *     <---Nextobjptr
     * objC
     * objB
     * objA
     * 
     * Our Application created a raw object called objD
     * Garbage collector will allocate memory for objD with in the
     * heap data structure where exactly next object pointer is pointing and
     * next object pointer will be moving to the next adjacent empty location
     * 
     * Managed Heap
     * 
     *     <--Nextobjptr
     * objD
     * objC
     * objB
     * objA
     * In this way Garbage Collector will allocate the memory for newly created objects
     * with in the heap data structure.
     * Garbage collector allocating memory for objects with in the heap continually
     * there is chance of out of memory.
     * To overcome this garbace collector is doing the second duty called deallocating
     * memory or releasing memory.
     * 
     * 2)Deallocating Memory:
     * deallocating memory is performed by the garbage collector in two steps
     * 1)Recognizing the unused objects/unreferenced objects.
     * 2)collection process.
     * 
     * 1)Recognizing the unused objects:
     * 
     * what is unreferenced object?
     * An object which is not pointing by any refenrece varibles will be called as 
     * unreferenced or unsed object.
     * As part of deallocation garbage collector will identity the unused objects with in the 
     * headp and it will give a tag called unused object .
     * 
     *   Managed Heap
     *        <---Next pointer
     *    objD
     *    objC==>unused
     *    objB
     *    objA==>unused
     * 
     * Here we have 4 objects among 4 objA and objC are unused objects and 
     * objB and objD are used objects.
     * In this way garbage collector will recognize unused objects.
     * 
     * 
     * Collection Process:
     * To implement collection process garbage collector will depend on
     * generation algorithm.
     * According to generation algorith , managed heap will be divided into
     * 3 generations .
     * 1)Generation 0: will contatin just now created objects.
     * 2)Generation 1: will contain just before created objects.
     * 3)Generation 2: will contain long before created objects.
     * 
     * Managed heap will be divide into 3 blocks.
     * Generation 0 block  space <Generatation 1 block space< Generation 2 block space
     * 
     * Managed heap
     * 
     *  Gen0
     * 
     *  Gen1
     * 
     *  Gen2
     *  
     *  what is collection process?
     *  Collection process is nothing but destroying all unused objects with in the current
     *  generation and moving all used objects from current generation to next generation.
     *  ex:generation 0 to generation 1.
     *  
     *  How garbage collector will implement collection process?
     *  when ever an application initalized all the generations of the managed heap will be empty.
     *  
     *  Managed Heap
     *  
     *         Gen0
     *         Gen1
     *         Gen2
     *         here all are empty.
     *         whenever a new object created by the application garbage collector will allocate 
     *         memory for newly created objects with in generation 0 continually till the generation 0 is full.
     *         
     *         Whenever generation 0 has no empty space then garbage collectr will perform the collection
     *         process with the generation 0 is nothing but destroing the all unused objects of generation 0 and 
     *         moving all used objects of generation 0 to generation 1.
     *         
     *         whenever generation 0 and generation 1 is full then garbage collector will perform the collection
     *         process in generation 1 first and go to second one means destroing all unsed objects with in the 
     *         generation 1 and moving all used objects of generation 1 to generation 2.
     *         
     *         whenever generation 0,generation1 and generation 2 are full then garbage collector will 
     *         perform the collection process with in generation 2 first here most of the objects are unused 
     *         objects due to that all unused objects of generation 2 will be destroyed.
     *         
     *         After this it will perform collection process in generation 1 and generation 2.
     *         This collection process is a cycling process.
     *         Finally with this we can say all new objects are allocating the memory with in 
     *         generation 0.
     *         
     *         Assume we have 3 objects 
     *         Managed Heap
     *         objC
     *         objB==>b is unused
     *         objA==>these 3 are unused and under 
     *             ===>gen 0
     *         
     *         
     *            ===>  gen 1
     *            
     *            
     *            ===>  gen 2
     *            
     *            According to generation 0 has no space as we have 3 objects
     *            due to that reason garbage collector will perform collection process within 
     *            gen 0 
     *            
     *            Managed Heap
     *            
     *                
     *                  ==>gen 0 is empty now
     *                
     *             objC
     *             objA===>gen 1
     *             
     *               
     *                  ==> gen 2 is empty.
     *                  
     *             newly created objects will be allocated into generation 0 once again.
     *             
     *             objF
     *             objE
     *             objD  ==>unused
     *                    >newly created objects under generation 0
     *                 ==>gen 0
     *             objC
     *             objA==>gen 1
     *             
     *             
     *             
     *                 ==>gen 2 is empty.
     *                 
     *                 here gen 0 is full due to that reason again garbage collector will 
     *                 perform collection process to gen0.
     *                 
     *                 
     *                 
     *                     ===>gen 0
     *                objF
     *                objE
     *                objC
     *                objA  ==>gen 1
     *                
     *                
     *                     ==>gen 2
     *                     
     *                     lets assume newly created objects will be allocated with in gen 0
     *                 
     *                 objI
     *                 objH==>unused
     *                 objG==> gen 0
     *                 objF
     *                 objE==>unused
     *                 objC
     *                 objA==>gen  1
     *                 
     *                 
     *                 
     *                     ===>gen  2
     *                     
     *                     Now we can say according to gen 1 and gen 0 are full
     *                      due to that reason garbage collector will implement the collection processfirst
     *                      in gen 1 and gen 0.
     *                      whenever these 3 generations are full first ggarbage collector will implemente
     *                      collection process in generation 2, generation 1 and generation 0. which is 
     *                      a cycling process.
     *                      
     *                 
     *                 
     *             
     *         
     *         
     *         
     * 
     * 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
