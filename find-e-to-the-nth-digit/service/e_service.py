from repository.e_repository import ERepository
from local.globals import E_URL


class EService:
    def __init__(self):
        self.e_repository = ERepository(E_URL)

    def get_e_to_n(self, n: int):
        e = self.e_repository.get_e()
        return e[0: n + 2]
