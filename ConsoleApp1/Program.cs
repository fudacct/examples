using System;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}


/*
 * let arr = [1, 2, 3, 4, 5, 6];
let treeNode = {
    root: "",
    leftChild: '',
    rightChild: '',
}

function Queue(value = []) {
    this.value = value;
    this.length = this.value.length;
    this.poll = function () {//剪枝，即删除元素
        let obj = this.value.shift();
        this.length = this.value.length;
        return obj;
    };
    this.offer = function (element) {//增加元素
        this.value.push(element)
        this.length = this.value.length;
    }
}

function createBinaryTree(node, i) {
    let leftIndex = i * 2 + 1;
    let rightIndex = i * 2 + 2;
    if (arr && arr.length < 1) return null;
    node.root = arr[i];
    if (leftIndex < arr.length) {
        node.leftChild = Object.create(treeNode);
        createBinaryTree(node.leftChild, leftIndex)
    }
    if (rightIndex < arr.length) {
        node.rightChild = Object.create(treeNode)
        createBinaryTree(node.rightChild, rightIndex)
    }
    return node
}

let node = Object.create(treeNode)

let tree = createBinaryTree(node, 0);
BFS(tree)
function BFS(tree) {
    let queue = new Queue();
    queue.offer(tree)
    while (queue.length) {
        let obj = queue.poll();
        console.log(obj.root)
        if (obj.leftChild) {
            queue.offer(obj.leftChild)
        }
        if (obj.rightChild) {
            queue.offer(obj.rightChild)
        }
    }
}
 * 
 * 
 * 
 * 
 */