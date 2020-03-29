from dependency_injector import providers, containers

from service.fibonacci_service import FibonacciService


class FibonacciContainer(containers.DeclarativeContainer):
    fibonacci_provider = providers.Singleton(FibonacciService)