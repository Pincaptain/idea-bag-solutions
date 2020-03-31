from dependency_injector import containers, providers

from service.factorization_service import FactorizationService


class FactorizationProvider(containers.DeclarativeContainer):
    factorization_service = providers.Singleton(FactorizationService)
