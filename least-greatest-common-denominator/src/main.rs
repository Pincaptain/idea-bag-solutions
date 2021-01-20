use clap::{App, Arg, ArgMatches};
use std::str::FromStr;

fn run(app: App) {
    let matches: ArgMatches = app.get_matches();

    let first: i32;
    let second: i32;

    match matches.value_of("first") {
        Some(value) => {
            match i32::from_str(value) {
                Ok(value) => first = value,
                Err(_) => {
                    panic!("First fraction denominator provided is not a valid integer!");
                }
            }
        }
        None => {
            panic!("First fraction denominator not provided!");
        }
    }

    match matches.value_of("second") {
        Some(value) => {
            match i32::from_str(value) {
                Ok(value) => second = value,
                Err(_) => {
                    panic!("Second fraction denominator provided is not a valid integer!");
                }
            }
        }
        None => {
            panic!("Second fraction denominator not provided!");
        }
    }

    let (gcd, lcm) = num::integer::gcd_lcm(first, second);

    println!("GCD: {}\nLCM: {}", gcd, lcm);
}

fn main() {
    let app: App = App::new("Least/Greatest Common Denominator")
        .version("1.0.0")
        .author("Borjan Gjorovski <borjan.gjorovski@outlook.com>")
        .about("Simple program that finds the least/greatest common denominator")
        .arg(Arg::with_name("first")
            .short("f")
            .long("first")
            .value_name("FIRST")
            .help("First fraction denominator to use in the calculation")
            .takes_value(true))
        .arg(Arg::with_name("second")
            .short("s")
            .long("second")
            .value_name("SECOND")
            .help("Second fraction denominator to use in the calculation")
            .takes_value(true));

    run(app);
}
