#include <iostream>

class BST {
    struct node {
        int data;
        node *left;
        node *right;
    };

    node *root;

    node *makeEmpty(node *t) {
        if (t == nullptr)
            return nullptr;
        {
            makeEmpty(t->left);
            makeEmpty(t->right);
            delete t;
        }
        return nullptr;
    }

    static node *newNode(int key) {
        node *newNode = new node;
        newNode->data = key;
        newNode->left = newNode->right = nullptr;
        return newNode;
    }

    static void insert(node *&root, int key) {
        // if the root is null, create a new node an return it
        if (root == nullptr) {
            root = newNode(key);
            return;
        }

        // if given key is less than the root node, recurse for left subtree
        // else recurse for right subtree
        if (key < root->data)
            insert(root->left, key);
        else // key >= root->data
            insert(root->right, key);
    }


    void PrintTree(node *t, int space) {
        if (t) {
            PrintTree(t->left, space + 5);
            for (int i = 0; i < space; i++)
                std::cout << ' ';
            std::cout << t->data << '\n';
            PrintTree(t->right, space + 5);
        }
    }

    node *findMin(node *t) {
        if (t == nullptr)
            return nullptr;
        else if (t->left == nullptr)
            return t;
        else
            return findMin(t->left);
    }

    node *findMax(node *t) {
        if (t == nullptr)
            return nullptr;
        else if (t->right == nullptr)
            return t;
        else
            return findMax(t->right);
    }

    int maxvalue(node *t) {
        if (t == nullptr)
            return -1;
        int root_val = t->data;
        int left_val = maxvalue(t->left);
        int right_val = maxvalue(t->right);
        if (left_val > root_val)
            root_val = left_val;
        if (right_val > root_val)
            root_val = right_val;
        return root_val;
    }

    node *remove(int x, node *t) {
        node *temp;
        if (t == nullptr)
            return nullptr;
        else if (x < t->data)
            t->left = remove(x, t->left);
        else if (x > t->data)
            t->right = remove(x, t->right);
        else if (t->left && t->right) {
            temp = findMin(t->right);
            t->data = temp->data;
            t->right = remove(t->data, t->right);
        } else {
            temp = t;
            if (t->left == nullptr)
                t = t->right;
            else if (t->right == nullptr)
                t = t->left;
            delete temp;
        }

        return t;
    }

    void inorder(node *t) {
        if (t == nullptr)
            return;
        inorder(t->left);
        std::cout << t->data << " ";
        inorder(t->right);
    }

    static node *find(node *t, int x) {
        if (t == nullptr)
            return nullptr;
        else if (x < t->data)
            return find(t->left, x);
        else if (x > t->data)
            return find(t->right, x);
        else
            return t;
    }

    static int minTreeDepth(node *t) {
        if ((t->right == nullptr) && (t->left == nullptr))
            return 0;
        if (t->left == nullptr)
            return minTreeDepth(t->right) + 1;
        else if (t->right == nullptr)
            return minTreeDepth(t->left) + 1;
        return std::min(minTreeDepth(t->left), minTreeDepth(t->right)) + 1;
    }

public:
    BST() { root = nullptr; }

    int minTreeDepth() { return minTreeDepth(root); }

    ~BST() { root = makeEmpty(root); }

    void insert(int x) { insert(root, x); }

    int max() { return findMax(root)->data; }

    void newPrint() { PrintTree(root, 0); }

    void remove(int x) { root = remove(x, root); }

    void display() {
        inorder(root);
        std::cout << std::endl;
    }

    void search(int x) { root = find(root, x); }
};
