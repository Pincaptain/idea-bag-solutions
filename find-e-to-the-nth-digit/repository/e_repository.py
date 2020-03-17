class ERepository:
    def __init__(self, url: str):
        self.url = url

    def get_e(self):
        with open(self.url, 'r') as file:
            return file.read()