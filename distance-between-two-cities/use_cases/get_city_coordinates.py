from configs.api_config import ApiConfig
from repositories.geolocation_repository import GeolocationRepository

api_config = ApiConfig()


def get_city_coordinates(city):
    geolocation_repository = GeolocationRepository(api_config.get_key())
    coordinates = geolocation_repository.get_coordinates(city)

    return coordinates
