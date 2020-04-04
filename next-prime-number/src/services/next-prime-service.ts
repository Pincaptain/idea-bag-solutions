export default function getNextPrime(num: number): number {
    if (num === 0 || num === 1) {
        return 2;
    }

    let current: number = num + 1;
    while (true) {
        let isPrime: boolean = true;

        if (current % 2 == 0) {
            current++;
            continue;
        }

        for (let i = 3; i < Math.sqrt(current) + 1; i += 2) {
            if (current % i == 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) {
            return current;
        }

        current++;
    }
}