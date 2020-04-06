import MortgageService from "./service/mortgage-service";

main(process.argv);

function main(args: string[]): void {
    if (args.length < 6) {
        console.log("Invalid number of parameters provided.");
        return;
    }

    let loan: number = parseInt(args[2]);
    let interest: number = parseFloat(args[3]);
    let term: number = parseInt(args[4]);
    let type: number = parseInt(args[5]);

    if (isNaN(loan) || isNaN(interest) || isNaN(term) || isNaN(type)) {
        console.log("Invalid parameters provided.");
        return;
    }

    let t = type == 1 ? MortgageService.type.DAILY :
        type == 2  ? MortgageService.type.MONTHLY : MortgageService.type.YEARLY;

    let mortgageService: MortgageService = new MortgageService(loan, interest, term);
    console.log(mortgageService.calculateMonthly(t));
}