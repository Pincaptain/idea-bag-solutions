import getNextPrime from "./services/next-prime-service";

main(process.argv);

function main(args:string[]) {
    if (args.length < 3) {
        console.log("Insufficient amount of parameters!");
        return;
    }

    let num: number = parseInt(args[2]);
    if (isNaN(num)) {
        console.log("Incorrect parameter type!");
        return;
    }

    num = getNextPrime(num);
    console.log(num);
}