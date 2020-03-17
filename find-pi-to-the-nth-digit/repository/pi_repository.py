class PiRepository:
    def __init__(self, url: str):
        self.url = url

    def get_pi(self):
        with open(self.url, 'r') as file:
            return file.read()
