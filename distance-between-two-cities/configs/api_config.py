import os

from configparser import ConfigParser


class ApiConfig:
    def __init__(self, config='../api.ini'):
        self.config = config

    def get_key(self):
        path = os.path.join(os.path.abspath(os.path.dirname(__file__)), '..', 'api.ini')
        config_parser = ConfigParser()
        config_parser.read(path)

        return config_parser['opencagedata.com']['key']
