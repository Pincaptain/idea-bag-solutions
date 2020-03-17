from repository.pi_repository import PiRepository
from local.globals import PI_URL


class PiService:
    def __init__(self):
        self.pi_repository = PiRepository(PI_URL)

    def get_pi_to_n(self, n: int):
        pi = self.pi_repository.get_pi()

        return pi[0:n + 2]