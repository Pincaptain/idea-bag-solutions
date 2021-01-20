extern crate clap;
use clap::{Arg, App};
use std::process::exit;
use std::str::FromStr;

#[allow(dead_code)]
#[allow(unused_variables)]
#[allow(unused_assignments)]

enum UnitType {
    Kilometer,
    Meter,
    Centimeter,
    Millimeter,
    Micrometer,
    Nanometre,
    Mile,
    Yard,
    Foot,
    Inch,
    NauticalMile
}

struct UnitConverter {}

impl UnitConverter {
    pub fn new() -> UnitConverter {
        return UnitConverter{};
    }

    pub fn str_to_unit(unit_str: String) -> UnitType {
        return match unit_str.as_str() {
            "km" => UnitType::Kilometer,
            "m" => UnitType::Meter,
            "cm" => UnitType::Centimeter,
            "mm" => UnitType::Millimeter,
            "μm" => UnitType::Micrometer,
            "nm" => UnitType::Nanometre,
            "mi" => UnitType::Mile,
            "yd" => UnitType::Yard,
            "ft" => UnitType::Foot,
            "in" => UnitType::Inch,
            "nmi" => UnitType::NauticalMile,
            _ => UnitType::Kilometer
        }
    }

    pub fn convert(&self, unit_type: UnitType, unit_to_type: UnitType, unit_value: f64) -> f64 {
        let kilometers: f64 = match unit_type {
            UnitType::Kilometer => unit_value,
            UnitType::Meter => unit_value / 1000.0,
            UnitType::Centimeter => unit_value / 100000.0,
            UnitType::Millimeter => unit_value / 1000000.0,
            UnitType::Micrometer => unit_value / 1000000000.0,
            UnitType::Nanometre => unit_value / 1000000000000.0,
            UnitType::Mile => unit_value * 1.60934,
            UnitType::Yard => unit_value / 1094.0,
            UnitType::Foot => unit_value / 3281.0,
            UnitType::Inch => unit_value / 39370.0,
            UnitType::NauticalMile => unit_value * 1.852
        };

        return match unit_to_type {
            UnitType::Kilometer => kilometers,
            UnitType::Meter => kilometers * 1000.0,
            UnitType::Centimeter => kilometers * 100000.0,
            UnitType::Millimeter => kilometers * 1000000.0,
            UnitType::Micrometer => kilometers * 1000000000.0,
            UnitType::Nanometre => kilometers * 1000000000000.0,
            UnitType::Mile => kilometers / 1.60934,
            UnitType::Yard => kilometers * 1093.61,
            UnitType::Foot => kilometers * 3280.84,
            UnitType::Inch => kilometers * 39370.1,
            UnitType::NauticalMile => kilometers / 1.852
        };
    }
}

fn main() {
    let matches = App::new("Unit Converter")
        .version("1.0.0")
        .author("Borjan Gjorovski <borjan.gjorovski@outlook.com>")
        .about("Simple application that provides unit conversion.")
        .arg(Arg::with_name("from")
            .short("f")
            .long("from")
            .value_name("FROM")
            .help("Unit from which you want to convert")
            .takes_value(true))
        .arg(Arg::with_name("to")
            .short("t")
            .long("to")
            .value_name("TO")
            .help("Unit to which you want to convert")
            .takes_value(true))
        .arg(Arg::with_name("value")
            .short("val")
            .long("value")
            .value_name("VALUE")
            .help("Unit value you want to convert")
            .takes_value(true))
        .get_matches();

    let unit_from: String;
    let unit_to: String;
    let value: String;

    if matches.is_present("from") {
        unit_from = matches.value_of("from")
            .unwrap()
            .parse()
            .unwrap();
    } else {
        exit(1);
    }

    if matches.is_present("to") {
        unit_to = matches.value_of("to")
            .unwrap()
            .parse()
            .unwrap();
    } else {
        exit(1);
    }

    if matches.is_present("value") {
        value = matches.value_of("value")
            .unwrap()
            .parse()
            .unwrap();
    } else {
        exit(1);
    }

    let unit_converter: UnitConverter = UnitConverter::new();

    let unit_type: UnitType = UnitConverter::str_to_unit(unit_from);
    let unit_to_type: UnitType = UnitConverter::str_to_unit(unit_to);
    let unit_value: f64 = f64::from_str(value.as_str()).unwrap();

    let conversion: f64 = unit_converter.convert(unit_type, unit_to_type, unit_value);

    println!("{}", conversion);
}
