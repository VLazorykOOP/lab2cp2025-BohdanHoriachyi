#include <iostream>
#include <thread>
#include <vector>
#include <random>
#include <chrono>
#include <mutex>
#include <string>

using namespace std;

const int WIDTH = 800;
const int HEIGHT = 600;
const int SPEED = 10;

mutex coutMutex;

struct Point {
    int x;
    int y;
};

class Vehicle {
private:
    Point position;
    Point target;
    string type;
    int id;

public:
    Vehicle(int _id, string _type, Point start, Point end)
        : id(_id), type(_type), position(start), target(end) {
    }

    void move() {
        while (position.x != target.x || position.y != target.y) {
            this_thread::sleep_for(chrono::milliseconds(100));

            if (position.x < target.x) position.x += SPEED;
            else if (position.x > target.x) position.x -= SPEED;

            if (position.y < target.y) position.y += SPEED;
            else if (position.y > target.y) position.y -= SPEED;

            lock_guard<mutex> lock(coutMutex);
            cout << "[" << type << " #" << id << "] Ruhayetsya: ("
                << position.x << ", " << position.y << ")" << endl;
        }

        lock_guard<mutex> lock(coutMutex);
        cout << "[" << type << " #" << id << "] Pribula do tsili." << endl;
    }
};

int getRandom(int min, int max) {
    static random_device rd;
    static mt19937 gen(rd());
    uniform_int_distribution<> dist(min, max);
    return dist(gen);
}

Point getRandomPoint(int x1, int y1, int x2, int y2) {
    return { getRandom(x1, x2), getRandom(y1, y2) };
}

int main() {
    vector<thread> threads;

    int numTrucks = 3;
    int numCars = 3;
    int idCounter = 1;

    for (int i = 0; i < numTrucks; ++i) {
        Point start = getRandomPoint(0, 0, WIDTH, HEIGHT);
        Point end = getRandomPoint(0, 0, WIDTH / 2, HEIGHT / 2);
        Vehicle* truck = new Vehicle(idCounter++, "Vantazhivka", start, end);
        threads.emplace_back(&Vehicle::move, truck);
    }

    for (int i = 0; i < numCars; ++i) {
        Point start = getRandomPoint(0, 0, WIDTH, HEIGHT);
        Point end = getRandomPoint(WIDTH / 2, HEIGHT / 2, WIDTH, HEIGHT);
        Vehicle* car = new Vehicle(idCounter++, "Legkova", start, end);
        threads.emplace_back(&Vehicle::move, car);
    }

    for (auto& t : threads) {
        t.join();
    }

    cout << "Simulyatsiyu zaversheno." << endl;
    return 0;
}
