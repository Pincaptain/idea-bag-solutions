import json

import requests


class GeolocationRepository:
    def __init__(self, key, url='https://api.opencagedata.com/geocode/v1/json'):
        self.key = key
        self.url = url

    def get_coordinates(self, city):
        url = f'{self.url}?q={city}&key={self.key}&language=en&pretty=1'
        response = requests.get(url)
        data = json.loads(response.content)
        has_results = True if len(data['results']) > 0 else False

        if not has_results:
            return None

        try:
            return data['results'][0]['geometry']
        except KeyError:
            return None
